import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { DetailsKandidatComponent } from './details-kandidat.component';
describe('DetailsKandidatComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [DetailsKandidatComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(DetailsKandidatComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=details-kandidat.component.spec.js.map