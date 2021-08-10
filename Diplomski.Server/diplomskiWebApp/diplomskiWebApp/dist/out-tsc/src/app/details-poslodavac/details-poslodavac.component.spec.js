import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { DetailsPoslodavacComponent } from './details-poslodavac.component';
describe('DetailsPoslodavacComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [DetailsPoslodavacComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(DetailsPoslodavacComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=details-poslodavac.component.spec.js.map