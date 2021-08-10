import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { PoslodavacOglasComponent } from './poslodavac-oglas.component';
describe('PoslodavacOglasComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [PoslodavacOglasComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(PoslodavacOglasComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=poslodavac-oglas.component.spec.js.map