import { __decorate } from "tslib";
import { Component } from '@angular/core';
let EditOglasComponent = class EditOglasComponent {
    constructor(fb, route, oglasService, getIndustrijeService, router, toastrService) {
        this.fb = fb;
        this.route = route;
        this.oglasService = oglasService;
        this.getIndustrijeService = getIndustrijeService;
        this.router = router;
        this.toastrService = toastrService;
        this.industrije = [];
        this.novaPitanja = [];
        this.izbrisanaPitanja = [];
        this.oglasForm = this.fb.group({
            'id': [''],
            'naziv': [''],
            'industrijaId': [''],
            'opis': ['']
        });
        this.pitanjeForm = this.fb.group({
            'pitanje': ['']
        });
    }
    ngOnInit() {
        this.fetchIndustrije();
        this.route.params.subscribe(params => {
            this.oglasId = params['id'];
            this.oglasService.getOglas(this.oglasId).subscribe(res => {
                this.oglas = res;
                this.oglasForm = this.fb.group({
                    'id': [this.oglas.id],
                    'naziv': [this.oglas.naziv],
                    'industrijaId': [this.oglas.industrijaId],
                    'opis': [this.oglas.opis]
                });
            });
        });
    }
    editOglas() {
        console.log(this.oglasForm.value);
        this.oglasService.editOglas(this.oglas.id, {
            'naziv': this.oglasForm.get('naziv').value,
            'industrijaId': Number(this.oglasForm.get('industrijaId').value),
            'opis': this.oglasForm.get('opis').value,
            'novaPitanja': this.novaPitanja,
            'obrisanaPitanjaIds': this.izbrisanaPitanja
        }).subscribe(res => {
            this.router.navigate(["oglaslist"]);
            this.toastrService.success("Oglas uspješno ažuriran.");
        });
        //this.oglasForm.value).subscribe(res => {
        // this.router.navigate(["oglaslist"])
        // })
    }
    fetchIndustrije() {
        this.getIndustrijeService.getIndustrije().subscribe(industrija => {
            this.industrije = industrija;
        });
    }
    deletePitanje(id) {
        var result = confirm("Želite li izbrisati pitanje?");
        if (result == true) {
            this.oglas.pitanja = this.oglas.pitanja.filter(p => p.id !== id);
            this.izbrisanaPitanja.push(id);
        }
    }
    deleteNovoPitanje(pitanje) {
        var result = confirm("Želite li izbrisati pitanje?");
        if (result == true) {
            this.novaPitanja = this.novaPitanja.filter(p => p !== pitanje);
        }
    }
    addQuestion() {
        if (this.pitanjeForm.value) {
            var pitanje = this.pitanjeForm.get('pitanje').value;
            this.novaPitanja.push(pitanje);
        }
    }
};
EditOglasComponent = __decorate([
    Component({
        selector: 'app-edit-oglas',
        templateUrl: './edit-oglas.component.html',
        styleUrls: ['./edit-oglas.component.css']
    })
], EditOglasComponent);
export { EditOglasComponent };
//# sourceMappingURL=edit-oglas.component.js.map