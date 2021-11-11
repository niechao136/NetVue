import type { Context } from '@nuxt/types'
import type { ActionTree, GetterTree, MutationTree } from 'vuex'

export interface RootState {
  description: string
}

export const state = (): RootState => ({
  description: "I'm defined as an initial state"
})

export const getters: GetterTree<RootState, RootState> = {
  reversedName: (state: RootState): string => state.description.split('').reverse().join('')
}

export const MutationType = {
  CHANGE_DESCRIPTION: 'changeDescription'
}

export const mutations: MutationTree<RootState> = {
  [MutationType.CHANGE_DESCRIPTION]: (state: RootState, newDescription: string) => {
    state.description = newDescription
  }
}

export const actions: ActionTree<RootState, RootState> = {
  nuxtServerInit({commit}: any, _context: Context) {
    commit(MutationType.CHANGE_DESCRIPTION, "I'm defined by server side")
  }
}
