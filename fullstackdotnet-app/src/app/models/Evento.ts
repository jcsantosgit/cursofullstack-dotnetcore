export interface Evento {
  id?: number;
  local: string;
  dataEvento?: Date;
  tema: string;
  qtdPublico: number;
  imageUrl: string;
  telefone: string;
  email: string;
  lotes: any;
  redesSociais: any;
  palestrantesEventos: any;
  includePalestrantes: boolean;
}
