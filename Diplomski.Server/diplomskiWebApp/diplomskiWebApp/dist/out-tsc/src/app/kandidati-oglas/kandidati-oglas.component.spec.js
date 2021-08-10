import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { KandidatiOglasComponent } from './kandidati-oglas.component';
describe('KandidatiOglasComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [KandidatiOglasComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(KandidatiOglasComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=kandidati-oglas.component.spec.js.map