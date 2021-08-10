import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
let CreateoglasComponent = class CreateoglasComponent {
    constructor(fb, oglasService, toastrService, router) {
        this.fb = fb;
        this.oglasService = oglasService;
        this.toastrService = toastrService;
        this.router = router;
        this.industrije = [];
        this.pitanja = [];
        this.oglasForm = this.fb.group({
            'naziv': ['', Validators.required],
            'industrijaId': ['', Validators.required],
            'opis': ['', Validators.required]
        });
        this.pitanjeForm = this.fb.group({
            'pitanje': ['']
        });
    }
    ngOnInit() {
        this.fetchIndustrije();
    }
    get naziv() {
        return this.oglasForm.get('naziv');
    }
    get industrijaId() {
        return this.oglasForm.get('industrijaId');
    }
    get opis() {
        return this.oglasForm.get('opis');
    }
    create() {
        console.log(this.oglasForm.value);
        this.oglasService
            .create({
            naziv: this.oglasForm.get('naziv').value,
            industrijaId: Number(this.oglasForm.get('industrijaId').value),
            opis: this.oglasForm.get('opis').value,
            pitanja: this.pitanja
        })
            .subscribe(res => {
            this.toastrService.success("Uspješno kreiran oglas");
            console.log(res);
            this.router.navigate(["oglaslist"]);
        });
    }
    fetchIndustrije() {
        this.oglasService.getIndustrije().subscribe(industrija => {
            this.industrije = industrija;
            console.log(this.industrije);
        });
    }
    addQuestion() {
        if (this.pitanjeForm.value) {
            var pitanje = this.pitanjeForm.get('pitanje').value;
            this.pitanja.push(pitanje);
        }
    }
    removeQuestion(question) {
        this.pitanja = this.pitanja.filter(q => q !== question);
    }
};
CreateoglasComponent = __decorate([
    Component({
        selector: 'app-createoglas',
        templateUrl: './createoglas.component.html',
        styleUrls: ['./createoglas.component.css']
    })
], CreateoglasComponent);
export { CreateoglasComponent };
//# sourceMappingURL=createoglas.component.js.map