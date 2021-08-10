import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { EditKandidatComponent } from './edit-kandidat.component';
describe('EditKandidatComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [EditKandidatComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(EditKandidatComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=edit-kandidat.component.spec.js.map