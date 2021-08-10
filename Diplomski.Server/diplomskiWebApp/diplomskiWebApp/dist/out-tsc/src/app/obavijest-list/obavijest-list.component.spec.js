import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { ObavijestListComponent } from './obavijest-list.component';
describe('ObavijestListComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [ObavijestListComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(ObavijestListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=obavijest-list.component.spec.js.map