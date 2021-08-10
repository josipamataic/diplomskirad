import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ListOglasComponent = class ListOglasComponent {
    constructor(oglasService, router, toastrService) {
        this.oglasService = oglasService;
        this.router = router;
        this.toastrService = toastrService;
    }
    ngOnInit() {
        this.fetchOglasi();
    }
    fetchOglasi() {
        this.oglasService.getOglasi().subscribe(oglas => {
            this.oglas = oglas;
            console.log(this.oglas);
        });
    }
    deleteOglas(id) {
        // var result = confirm("Želite li izbrisati oglas?");
        // if(result == true){
        console.log("hello");
        this.oglasService.deleteOglas(id).subscribe(res => {
            this.toastrService.success("Oglas uspješno obrisan.");
            this.fetchOglasi();
        });
        // }
    }
    arhivirajOglas(id) {
        this.oglasService.arhivirajOglas(id).subscribe(res => {
            this.toastrService.success("Oglas arhiviran.");
            this.fetchOglasi();
        });
    }
    editOglas(id) {
        this.router.navigate(["oglas/" + id + "/edit"]);
    }
};
ListOglasComponent = __decorate([
    Component({
        selector: 'app-list-oglas',
        templateUrl: './list-oglas.component.html',
        styleUrls: ['./list-oglas.component.css']
    })
], ListOglasComponent);
export { ListOglasComponent };
//# sourceMappingURL=list-oglas.component.js.map