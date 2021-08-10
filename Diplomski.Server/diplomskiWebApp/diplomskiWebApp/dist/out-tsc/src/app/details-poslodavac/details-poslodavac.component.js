import { __decorate } from "tslib";
import { Component } from '@angular/core';
let DetailsPoslodavacComponent = class DetailsPoslodavacComponent {
    constructor(poslodavacService) {
        this.poslodavacService = poslodavacService;
    }
    ngOnInit() {
        this.fetchProfil();
    }
    fetchProfil() {
        this.poslodavacService.getMyProfile().subscribe(profil => {
            this.poslodavac = profil;
        });
    }
};
DetailsPoslodavacComponent = __decorate([
    Component({
        selector: 'app-details-poslodavac',
        templateUrl: './details-poslodavac.component.html',
        styleUrls: ['./details-poslodavac.component.css']
    })
], DetailsPoslodavacComponent);
export { DetailsPoslodavacComponent };
//# sourceMappingURL=details-poslodavac.component.js.map