import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { map, mergeMap } from 'rxjs/operators';
let KandidatiPoslodavacComponent = class KandidatiPoslodavacComponent {
    constructor(fb, oglasService, router, route, toastrService) {
        this.fb = fb;
        this.oglasService = oglasService;
        this.router = router;
        this.route = route;
        this.toastrService = toastrService;
        this.kandidatIds = [];
        this.obavijestForm = this.fb.group({
            'naslov': ['', Validators.required],
            'tekst': ['', Validators.required]
        });
    }
    ngOnInit() {
        // this.fetchKandidati()
        this.fetchOglas();
    }
    posaljiObavijest() {
        this.oglasService.posaljiObavijest({
            idOglas: this.id,
            naslov: this.obavijestForm.get('naslov').value,
            tekst: this.obavijestForm.get('tekst').value,
            kandidatIds: this.kandidatIds
        }).subscribe(res => {
            this.toastrService.success("Obavijest poslana.");
            this.router.navigate(["oglaslist"]);
        });
    }
    fetchOglas() {
        this.route.params.pipe(map(params => {
            this.id = params['id'];
        }), mergeMap(id => this.oglasService.getOglas(this.id))).subscribe(res => {
            this.oglas = res;
            this.fetchKandidati(this.id);
        });
    }
    fetchKandidati(id) {
        this.oglasService.getMyKandidati(id).subscribe(res => {
            this.kandidati = res;
            console.log(this.kandidati);
        });
    }
    get naslov() {
        return this.obavijestForm.get('naslov');
    }
    get tekst() {
        return this.obavijestForm.get('tekst');
    }
    addKandidatId(kandidat) {
        this.kandidatIds.push(kandidat.id);
        kandidat.oznacen = true;
    }
    removeKandidatId(kandidat) {
        this.kandidatIds = this.kandidatIds.filter(q => q != kandidat.id);
        kandidat.oznacen = false;
    }
};
KandidatiPoslodavacComponent = __decorate([
    Component({
        selector: 'app-kandidati-poslodavac',
        templateUrl: './kandidati-poslodavac.component.html',
        styleUrls: ['./kandidati-poslodavac.component.css']
    })
], KandidatiPoslodavacComponent);
export { KandidatiPoslodavacComponent };
//# sourceMappingURL=kandidati-poslodavac.component.js.map