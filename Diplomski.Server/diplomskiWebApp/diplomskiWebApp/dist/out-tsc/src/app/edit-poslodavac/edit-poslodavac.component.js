import { __decorate } from "tslib";
import { Component } from '@angular/core';
let EditPoslodavacComponent = class EditPoslodavacComponent {
    constructor(fb, router, poslodavacService, toastrService) {
        this.fb = fb;
        this.router = router;
        this.poslodavacService = poslodavacService;
        this.toastrService = toastrService;
        this.industrije = [];
        this.poslodavacForm = this.fb.group({
            //  'userName' : [''],
            // 'email':  [''],
            'nazivFirme': [''],
            'kontakt': [''],
            'email': [''],
            'industrijaId': [''],
            'opis': [''],
            'zemlja': [''],
            'privatniProfil': ['']
        });
    }
    ngOnInit() {
        this.fetchIndustrije();
        this.poslodavacService.getMyProfile().subscribe(podaci => {
            this.poslodavac = podaci;
            console.log(podaci);
            this.poslodavacForm = this.fb.group({
                // 'userName' : [this.poslodavac.userName],
                'nazivFirme': [this.poslodavac.nazivFirme],
                'kontakt': [this.poslodavac.kontakt],
                'email': [this.poslodavac.email],
                'industrijaId': [this.poslodavac.industrijaId],
                'opis': [this.poslodavac.opis],
                'zemlja': [this.poslodavac.zemlja],
                'privatniProfil': [this.poslodavac.privatniProfil]
            });
        });
    }
    editPoslodavac() {
        this.poslodavacService.editPoslodavac({
            'nazivFirme': this.poslodavacForm.get('nazivFirme').value,
            'kontakt': this.poslodavacForm.get('kontakt').value,
            'email': this.poslodavacForm.get('email').value,
            'industrijaId': Number(this.poslodavacForm.get('industrijaId').value),
            'opis': this.poslodavacForm.get('opis').value,
            'zemlja': this.poslodavacForm.get('zemlja').value,
            'privatniProfil': this.poslodavacForm.get('privatniProfil').value === "true" ? true : false
        }).subscribe(res => {
            this.toastrService.success("Podaci profila su ažurirani.");
            this.router.navigate(["poslodavac/myprofile"]);
            console.log(this.poslodavacForm.value);
        });
    }
    fetchIndustrije() {
        this.poslodavacService.getIndustrije().subscribe(industrija => {
            this.industrije = industrija;
            console.log(this.industrije);
        });
    }
};
EditPoslodavacComponent = __decorate([
    Component({
        selector: 'app-edit-poslodavac',
        templateUrl: './edit-poslodavac.component.html',
        styleUrls: ['./edit-poslodavac.component.css']
    })
], EditPoslodavacComponent);
export { EditPoslodavacComponent };
//# sourceMappingURL=edit-poslodavac.component.js.map