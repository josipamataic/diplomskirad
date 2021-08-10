import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { UvjetiKoristenjaComponent } from './uvjeti-koristenja.component';
describe('UvjetiKoristenjaComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [UvjetiKoristenjaComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(UvjetiKoristenjaComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=uvjeti-koristenja.component.spec.js.map