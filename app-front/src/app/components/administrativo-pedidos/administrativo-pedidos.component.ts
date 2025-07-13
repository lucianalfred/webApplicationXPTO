import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { PedidoService } from '../../core/services/pedido.service';
import { HeaderComponent } from '../header/header.component';
import { AdministrativoNavigationComponent } from '../administrativo-navigation/administrativo-navigation.component';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-administrativo-pedidos',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HeaderComponent,
    AdministrativoNavigationComponent,
    FormsModule
  ],
  templateUrl: './administrativo-pedidos.component.html',
  styleUrl: './administrativo-pedidos.component.css'
})
export class AdministrativoPedidosComponent {

  private pedidoSvc = inject(PedidoService);
  private fb = inject(FormBuilder);

  pedidos: any[] = [];
  filtroEstado = signal<'Todos' | 'EmEspera' | 'Agendado' | 'Concluido'>('Todos');


  modalAberto = signal(false);
  pedidoSel: any = null;

  fbForm = this.fb.group({
    estado: '',
    dataAgendamento: [new Date()],         
    feedback: ['']
  });


  salvarAlteracoes() {
    const { dataAgendamento, feedback } = this.fbForm.value;
    this.pedidoSvc.agendar(this.pedidoSel.id, dataAgendamento!, feedback!)
      .subscribe(() => { this.carregar(); this.fecharModal(); });
  }
  ngOnInit() { this.carregar(); }

  carregar() {
    this.pedidoSvc.getAll().subscribe(dados => {
      this.pedidos = dados
      console.log(dados);
    }
    );
  }
  pedidosFiltrados() {
    const f = this.filtroEstado();
    return f === 'Todos' ? this.pedidos
      : this.pedidos.filter(p => p.estado === f);
  }

  abrirDetalhes(p: any) {
    this.pedidoSel = p;
    this.fbForm.patchValue({ estado: p.estado, feedback: p.feedback });
    this.modalAberto.set(true);
  }
  fecharModal() { this.modalAberto.set(false); }

  /*salvarAlteracoesEstado() {
    if (!this.pedidoSel) return;

    const { estado, feedback } = this.fbForm.value;
    this.pedidoSvc.updateEstado(this.pedidoSel.id, estado!, feedback!)
      .subscribe(() => {
        this.carregar();
        this.fecharModal();
      });
  }*/
}
