import { FeriadoDto } from "./feriado-dto";

export class ListFeriados {
  feriados !: Array<FeriadoDto>;
 quantidadeFeriados !: number;
 error !: Array<string>;
 isSucess !: boolean;
}
