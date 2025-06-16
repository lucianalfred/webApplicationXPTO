export interface PedidoDeMarcacaoDTO {
  id: number;
  estadoDoPedidoDeMarcacao: number;
  dataDeAgendamento: string;
}

export enum EstadoDoPedidoDeMarcacao {
  PEDIDO = 0,
  AGENDADO = 1,
  REALIZADO = 2
}
