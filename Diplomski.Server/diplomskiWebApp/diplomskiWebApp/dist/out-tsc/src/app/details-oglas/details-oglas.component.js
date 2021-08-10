import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { map, mergeMap } from 'rxjs/operators';
let DetailsOglasComponent = class DetailsOglasComponent {
    // pitanjeId: number;
    //odgovorTekst: string;
    //odgovori: PitanjeOdgovor[] = [];
    constructor(fb, route, oglasService, toastrService, auth, router) {
        this.fb = fb;
        this.route = route;
        this.oglasService = oglasService;
        this.toastrService = toastrService;
        this.auth = auth;
        this.router = router;
        this.prijavaMode = false;
        this.postojiPrijava = false;
        // this.route.params.subscribe(res => {
        //   this.id = res['id'];
        //   this.oglasService.getOglas(this.id).subscribe( res => {
        //     this.oglas = res;
        //   })
        // })
        if (this.isUserKandidat) {
            this.checkPostojiLiPrijava();
        }
        this.fetchData();
    }
    fetchData() {
        this.route.params.pipe(map(params => {
            const id = params['id'];
            return id;
        }), mergeMap(id => this.oglasService.getOglas(id))).subscribe(res => {
            this.oglas = res;
            this.createOdgovoriForm = this.fb.group({
                // odgovori : this.fb.array([
                //this.fb.group({
                //  pitanjeId: [''],
                // odgovorTekst: ['']
                // })
                //   ])
                odgovori: this.fb.array([])
            });
            this.initFormArray();
        });
    }
    ngOnInit() {
        console.log("Hello");
    }
    onPrijaviSe() {
        console.log(this.oglas.pitanja);
        this.prijavaMode = true;
    }
    createPrijava() {
        if (this.usporedipitanjeodgovor()) {
            console.log(this.createOdgovoriForm);
            console.log(this.createOdgovoriForm.value);
            this.oglasService.createPrijava({
                oglasId: this.oglas.id,
                odgovori: this.odgovor.value
            })
                .subscribe(res => {
                this.toastrService.success("Uspješno kreirana prijava");
                this.router.navigate(["prijava/myprijave"]);
                console.log(res);
            });
        }
        else {
            this.toastrService.warning("Unesite odgovore na sva pitanja.");
        }
    }
    usporedipitanjeodgovor() {
        var odgovori = this.odgovor.value;
        return this.oglas.pitanja.length == odgovori.filter(o => o.odgovorTekst != '').length;
    }
    get odgovor() {
        return this.createOdgovoriForm.get("odgovori");
    }
    get isUserKandidat() {
        return this.auth.isUserKandidat();
    }
    get isUserPoslodavac() {
        return this.auth.isUserPoslodavac();
    }
    initFormArray() {
        console.log(this.oglas.pitanja);
        this.oglas.pitanja.forEach(element => {
            this.odgovor.push(this.fb.group({ pitanjeId: [element.id], odgovorTekst: [''] }));
        });
    }
    checkPostojiLiPrijava() {
        this.route.params.pipe(map(params => {
            const id = params['id'];
            return id;
        }), mergeMap(id => this.oglasService.checkPostojiLiPrijava(id))).subscribe(res => {
            this.postojiPrijava = res;
        });
    }
};
DetailsOglasComponent = __decorate([
    Component({
        selector: 'app-details-oglas',
        templateUrl: './details-oglas.component.html',
        styleUrls: ['./details-oglas.component.css']
    })
], DetailsOglasComponent);
export { DetailsOglasComponent };
//# sourceMappingURL=details-oglas.component.js.map