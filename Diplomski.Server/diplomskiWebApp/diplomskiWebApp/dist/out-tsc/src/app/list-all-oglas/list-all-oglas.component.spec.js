import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { ListAllOglasComponent } from './list-all-oglas.component';
describe('ListAllOglasComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [ListAllOglasComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(ListAllOglasComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=list-all-oglas.component.spec.js.map