import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { PolitikaPrivatnostiComponent } from './politika-privatnosti.component';
describe('PolitikaPrivatnostiComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [PolitikaPrivatnostiComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(PolitikaPrivatnostiComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=politika-privatnosti.component.spec.js.map