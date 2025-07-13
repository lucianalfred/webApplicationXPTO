import { Component, inject, OnInit, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AuthService } from '../../core/auth.service';
import { HeaderComponent } from '../header/header.component';
import { NavigationComponent } from '../navigation/navigation.component';

import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import type { TDocumentDefinitions } from 'pdfmake/interfaces';

interface HistoricoPedido {
  id: number;
  estado: string;
  intervaloDatas: string;
  dataAgendamento?: string;
  observacoes?: string;
  utenteRegistadoId: number;
  idUsuario: number,
  actosClinico?: any[];
}

@Component({
  selector: 'app-historico-marcacoes',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    NavigationComponent
  ],
  templateUrl: './historico-marcacoes.component.html',
  styleUrl: './historico-marcacoes.component.css'
})
export class HistoricoMarcacoesComponent implements OnInit {

  private http = inject(HttpClient);
  private auth = inject(AuthService);
  private router = inject(Router);

  carregando = signal(true);
  historico = signal<HistoricoPedido[]>([]);

  // estado do modal
  modalAberto = signal(false);
  pedidoSelecionado = signal<HistoricoPedido | null>(null);

  ngOnInit() {
    const id = this.auth.userId(); 
    this.http.get<HistoricoPedido[]>(
      `http://localhost:5026/api/PedidoDeMarcacao/usuario/${id}`
    ).subscribe({
      next: dados => { this.historico.set(dados); this.carregando.set(false); },
      error: _ => { this.carregando.set(false); }
    });
  }

  // gerar pdf 
  gerarPdf(ped: HistoricoPedido) {
    const docDefinition: TDocumentDefinitions = {
      content: [
        { text: 'Clínica XPTO', style: 'clinicName' },
        { text: 'Confirmação de Pedido de Marcação', style: 'header' },

        {
          columns: [
            { width: '50%', text: `ID Pedido: ${ped.id}` },
            { width: '50%', text: `Estado: ${ped.estado}` }
          ]
        },
        {
          columns: [
            { width: '50%', text: `Intervalo: ${ped.intervaloDatas}` },
            { width: '50%', text: `Agendamento: ${ped.dataAgendamento ?? '---'}` }
          ]
        },

        { text: `Observações: ${ped.observacoes ?? '-'}` },

        { text: ' ', margin: [0, 12] },

        { text: 'Actos Clínicos', style: 'subheader' },
        {
          ul: ped.actosClinico?.map((a, i) =>
            `#${i + 1} - Tipo: ${a.tipoDeActoClinico} | Subsistema: ${a.subSistemaDeSaude} | Profissional: ${a.profissionalId ?? 'N/A'}`
          ) || ['Nenhum acto encontrado.']
        },

        { text: '\nEmitido em: ' + new Date().toLocaleString(), margin: [0, 20, 0, 0], fontSize: 10, alignment: 'right' }
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

    pdfMake.createPdf(docDefinition).download(`Marcacao_${ped.id}.pdf`);

  }


  /** abre modal de detalhe */
  verDetalhes(p: HistoricoPedido) {
    this.pedidoSelecionado.set(p);
    this.modalAberto.set(true);
  }

  fecharModal() {
    this.modalAberto.set(false);
  }

  /** navega para a página de nova marcação já levando os dados */
  repetir(p: HistoricoPedido) {
    this.router.navigate(
      ['/utente/nova-marcacao'],
      { state: { pedido: p } }
    );
  }
}
