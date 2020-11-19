import {
    Store
} from "vuex";
import {
    getModule
} from "vuex-module-decorators";
import global from "~/store/global";

let globalStore: global;

function initializeStores(store: Store<any>): void {
    globalStore = getModule(global, store);
}

export {
    initializeStores,
    globalStore,
}
