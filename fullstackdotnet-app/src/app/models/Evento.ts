export interface Evento {
  id?: number;
  local: string;
  dataEvento: string;
  tema: string;
  qtdPublico: number;
  imageUrl: string;
  telefone: string;
  email: string;
  conteudo: string;
  lotes: any;
  redesSociais: any;
  palestrantesEventos: any;
  includePalestrantes: boolean;
}
