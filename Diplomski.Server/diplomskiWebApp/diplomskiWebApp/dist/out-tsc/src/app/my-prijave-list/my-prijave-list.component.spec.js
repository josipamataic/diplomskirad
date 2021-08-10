import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { MyPrijaveListComponent } from './my-prijave-list.component';
describe('MyPrijaveListComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [MyPrijaveListComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(MyPrijaveListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=my-prijave-list.component.spec.js.map