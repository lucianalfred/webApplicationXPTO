import { Component, signal } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, FormArray } from '@angular/forms';
import { HeaderComponent } from '../../../components/header/header.component';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import type { TDocumentDefinitions } from 'pdfmake/interfaces';

(pdfMake as any).vfs = pdfFonts.vfs;
@Component({
  selector: 'app-pedido-anonimo',
  standalone: true,
  imports: [HeaderComponent, CommonModule, ReactiveFormsModule],
  templateUrl: './pedido-anonimo.component.html'
})


export class PedidoAnonimoComponent {
  step = signal(1);
  modalAberto = signal(false);
  form!: FormGroup;
  fotoBase64: string = '';

  tiposConsulta = ['Consulta Geral', 'Exame Oftalmológico', 'Exame Cardiológico'];
  subsistemas = ['SNS', 'Medis', 'Multicare', 'Privado'];

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) {
    this.form = this.fb.group({
      numeroUtente: ['', Validators.required],
      nome: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      genero: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', Validators.required],
      morada: ['', Validators.required],
      foto: [null],
      actosClinicos: this.fb.array([]),
      intervaloDatas: ['', Validators.required],
      horarioSolicitado: ['', Validators.required],
      observacoes: ['']
    });

    // Adiciona pelo menos um acto clínico por padrão
    this.addActoClinico();
  }

  get actosClinicos() {
    return this.form.get('actosClinicos') as FormArray;
  }



  nextStep() {
    if (this.step() < 3) {
      this.step.update(v => v + 1);
    }
  }

  prevStep() {
    if (this.step() > 1) {
      this.step.update(v => v - 1);
    }
  }


  goToStep(num: number) {
    this.step.set(num);
  }
  addActoClinico() {
    this.actosClinicos.push(this.fb.group({
      tipo: ['', Validators.required],
      subsistema: ['', Validators.required],
      profissional: ['']
    }));
  }

  removeActoClinico(index: number) {
    this.actosClinicos.removeAt(index);
  }

  onFileChange(event: Event) {
    const input = event.target as HTMLInputElement;
    const file = input.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => this.fotoBase64 = reader.result as string;
      reader.readAsDataURL(file);
    }
  }

  gerarPdf() {
    const pedido = {
      numeroUtente: this.form.value.numeroUtente,
      email: this.form.value.email,
      telefone: this.form.value.telefone,
      genero: this.form.value.genero,
      intervaloDatas: this.form.value.intervaloDatas,
      horarioSolicitado: this.form.value.horarioSolicitado,
      observacoes: this.form.value.observacoes,
      utente: {
        nome: this.form.value.nome,
        password: 'anonimo123', // se necessário (ou pode omitir da API)
        dataNascimento: this.form.value.dataNascimento,
        morada: this.form.value.morada,
        urlDaFotografia: this.fotoBase64 || null,
        estadoDoUtilizador: true,
        tipoUtilizador: 'Utente'
      },
      actosClinicos: this.form.value.actosClinicos.map((acto: any) => ({
        TipoDeActoClinico: acto.tipo,
        subsistema: acto.subsistema,
        profissionalId: acto.profissional || null
      }))
    };

    const docDefinition: TDocumentDefinitions = {
      content: [
        { text: 'Clínica XPTO', style: 'clinicName' },
        { text: 'Confirmação de Pedido de Marcação', style: 'header' },

        {
          columns: [
            { width: '50%', text: `Nome: ${pedido.utente.nome}` },
            { width: '50%', text: `Gênero: ${pedido.genero}` }
          ]
        },
        {
          columns: [
            { width: '50%', text: `Data de Nascimento: ${pedido.utente.dataNascimento}` },
            { width: '50%', text: `Nº Utente: ${pedido.numeroUtente}` }
          ]
        },
        { text: `Morada: ${pedido.utente.morada}` },
        { text: `Email: ${pedido.email}` },
        { text: `Telefone: ${pedido.telefone}` },
        { text: `Intervalo de Datas: ${pedido.intervaloDatas}` },
        { text: `Horário Solicitado: ${pedido.horarioSolicitado}` },
        { text: `Observações: ${pedido.observacoes || '-'}` },

        { text: ' ', margin: [0, 12] },

        { text: 'Actos Clínicos Solicitados', style: 'subheader' },
        {
          ul: pedido.actosClinicos.map((acto: any, i: number) =>
            `#${i + 1} - Tipo: ${acto.TipoDeActoClinico} | Subsistema: ${acto.subsistema} | Profissional: ${acto.profissional || 'N/A'}`
          )
        },

        { text: '\nObrigado pelo seu contato.', italics: true, margin: [0, 20, 0, 0] }
      ],
      styles: {
        clinicName: {
          fontSize: 22,
          bold: true,
          color: '#2196f3',
          marginBottom: 10,
          alignment: 'center'
        },
        header: {
          fontSize: 16,
          bold: true,
          marginBottom: 16,
          alignment: 'center'
        },
        subheader: {
          fontSize: 14,
          bold: true,
          marginBottom: 8,
          color: '#1976d2'
        }
      }
    };

    ///
    pdfMake.createPdf(docDefinition).open();
  }
  fecharModal() {
    this.modalAberto.set(false);
    this.router.navigate(['/home']);
  };

  submit() {
    if (this.form.invalid) {
      alert("Formulário inválido");
      console.log("FOrmulario : ", this.form.value);
      return;
    }

    const pedido = {
      numeroUtente: this.form.value.numeroUtente,
      email: this.form.value.email,
      telefone: this.form.value.telefone,
      genero: this.form.value.genero,
      intervaloDatas: this.form.value.intervaloDatas,
      horarioSolicitado: this.form.value.horarioSolicitado,
      observacoes: this.form.value.observacoes,
      utente: {
        nome: this.form.value.nome,
        password: 'anonimo123', // se necessário (ou pode omitir da API)
        dataNascimento: this.form.value.dataNascimento,
        morada: this.form.value.morada,
        urlDaFotografia: this.fotoBase64 || null,
        estadoDoUtilizador: true,
        tipoUtilizador: 'Utente'
      },
      actosClinicos: this.form.value.actosClinicos.map((acto: any) => ({
        TipoDeActoClinico: acto.tipo,
        subsistema: acto.subsistema,
        profissionalId: acto.profissional || null
      }))
    };

    ///


    this.http.post('http://localhost:5026/api/PedidoDeMarcacao/anonimo', pedido).subscribe({
      next: () => {
        this.modalAberto.set(true);
      },
      error: err => console.error('Erro ao enviar pedido:', err)
    });
  }

}

