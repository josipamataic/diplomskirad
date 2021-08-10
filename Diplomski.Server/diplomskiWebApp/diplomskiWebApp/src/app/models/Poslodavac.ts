import { Industrija } from "./Oglas";

export interface Poslodavac{
    id: string,
    userName: string,
    email: string,
    nazivFirme: string,
    industrijaId?: number,
    industrija: Industrija,
    kontakt: string,
    opis: string,
    zemlja: string,
    privatniProfil: boolean
}

export interface Kandidat{

    userName: string,
    ime: string,
    prezime: string,
    email: string,
    brojMobitela: string,
    datumRodenja: Date,
    industrijaId?: number,
    industrija: Industrija,
    obrazovanje: string,
    zemlja: string,
    privatniProfil: boolean
}