"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Utilities = /** @class */ (function () {
    function Utilities() {
    }
    Utilities.prototype.getBoolean = function (value) {
        switch (value) {
            case true:
            case "true":
            case 1:
            case "1":
            case "on":
            case "yes":
                return true;
            default:
                return false;
        }
    };
    return Utilities;
}());
exports.Utilities = Utilities;
//# sourceMappingURL=utilities.js.map