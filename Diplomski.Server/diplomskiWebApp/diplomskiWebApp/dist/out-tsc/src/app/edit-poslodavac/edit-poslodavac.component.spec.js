import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { EditPoslodavacComponent } from './edit-poslodavac.component';
describe('EditPoslodavacComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [EditPoslodavacComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(EditPoslodavacComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=edit-poslodavac.component.spec.js.map