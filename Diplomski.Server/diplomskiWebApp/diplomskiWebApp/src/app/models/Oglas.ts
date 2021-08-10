export interface Oglas{
    id: number;
    naziv: string;
    industrijaId?: number;
    industrija: Industrija;
    opis?: string;
    poslodavacId?: string;
    firma?: string;
    userName?: string;
    datum?: Date;
    pitanja: Pitanje[];
    arhiviran: boolean;
}

export interface Pitanje {
    id: number;
    tekst: string;
}

export interface OglasList{
    id: number;
    poslodavacId: string;
    naziv: string;
    industrijaId?: number;
    industrija: string;
    opis: string;
    firma: string;
    lokacija: string;
    datum: Date;
}

export interface MyPrijave {
    id: number;
    oglasId: number;
    nazivOglas: string;
    industrija: string;
    opis: string;
    firma: string;
    datumPrijave: Date;
    pitanjeOdgovor: PitanjeIOdgovor[];
}

export interface PitanjeIOdgovor{
    tekstPitanje: string;
    tekstOdgovor: string;
}

export interface LoginResponseModel {
    token: string;
    role: string;
}

export enum Roles {
    kandidat = 'Kandidat',
    poslodavac = 'Poslodavac'
}

export interface Industrija{
    id: number;
    naziv: string;
}

export interface PitanjeOdgovor{
    pitanjeId: number;
    odgovorTekst: string;
}

export interface KandidatDetailsModel{
    id: string;
    ime: string;
    prezime: string;
    datumRodenja: Date;
    industrija: string;
    obrazovanje: string;
    zemlja: string;
    email: string;
    brojMobitela: string;
    datumPrijave: Date;
    odgovori: KandidatOdgovor[];
    oznacen: boolean;
}

export interface KandidatOdgovor{
    pitanjeId: number;
    tekstPitanje: string;
    odgovorId: number;
    tekstOdgovor: string;
}

export interface CreateObavijestModel{
    oglasId: number;
    naslov: string;
    tekst: string;
    kandidatIds: string[];
}

export interface ObavijestDetailsModel{
    naslov: string;
    tekst: string;
    oglasId: number;
    nazivOglas: number;
    poslodavacId: string;
    nazivPoslodavca: string;
    created: Date;
}