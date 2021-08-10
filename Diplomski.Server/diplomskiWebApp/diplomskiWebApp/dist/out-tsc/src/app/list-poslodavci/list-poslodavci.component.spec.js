import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { ListPoslodavciComponent } from './list-poslodavci.component';
describe('ListPoslodavciComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [ListPoslodavciComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(ListPoslodavciComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=list-poslodavci.component.spec.js.map