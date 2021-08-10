import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { KandidatiPoslodavacComponent } from './kandidati-poslodavac.component';
describe('KandidatiPoslodavacComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [KandidatiPoslodavacComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(KandidatiPoslodavacComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=kandidati-poslodavac.component.spec.js.map