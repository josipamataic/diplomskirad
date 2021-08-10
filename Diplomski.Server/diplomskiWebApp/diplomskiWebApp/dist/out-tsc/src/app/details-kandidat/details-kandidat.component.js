import { __decorate } from "tslib";
import { Component } from '@angular/core';
let DetailsKandidatComponent = class DetailsKandidatComponent {
    constructor(kandidatService, router, toastrService, auth) {
        this.kandidatService = kandidatService;
        this.router = router;
        this.toastrService = toastrService;
        this.auth = auth;
    }
    ngOnInit() {
        this.fetchProfil();
    }
    fetchProfil() {
        this.kandidatService.getMyProfile().subscribe(profil => {
            this.kandidat = profil;
            console.log(profil);
        });
    }
    deleteKandidat() {
        this.kandidatService.deleteKandidat().subscribe(res => {
            this.toastrService.success("Osobni podaci obrisani");
            this.fetchProfil();
        });
    }
    deleteUser() {
        this.kandidatService.deleteUser().subscribe(res => {
            this.auth.deleteToken();
            this.toastrService.error("Profil obrisan");
            this.router.navigate(["register"]);
        });
    }
};
DetailsKandidatComponent = __decorate([
    Component({
        selector: 'app-details-kandidat',
        templateUrl: './details-kandidat.component.html',
        styleUrls: ['./details-kandidat.component.css']
    })
], DetailsKandidatComponent);
export { DetailsKandidatComponent };
//# sourceMappingURL=details-kandidat.component.js.map