import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { ListKandidatiComponent } from './list-kandidati.component';
describe('ListKandidatiComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [ListKandidatiComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(ListKandidatiComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=list-kandidati.component.spec.js.map