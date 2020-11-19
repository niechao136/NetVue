import {
    Action,
    Module,
    Mutation,
    VuexModule
} from "vuex-module-decorators";

@Module({
    stateFactory: true,
    namespaced: true,
    name: "global"
})
export default class global extends VuexModule {

    lang: string = "";

    @Mutation langSet(lang: string) {
        this.lang = lang;
    }

    @Action setLang(lang: string) {
        this.context.commit("langSet", lang);
    }

}
