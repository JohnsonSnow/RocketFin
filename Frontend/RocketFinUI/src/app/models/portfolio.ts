
export interface Portfolio {
    value: Value
    isSuccess: boolean
    isFailure: boolean
    error: Error
  }
  
  export interface Value {
    items: Item[]
    page: number
    pageSize: number
    totalCount: number
    hasNextPage: boolean
    hasPrevious: boolean
  }
  
  export interface Item {
    symbol: string
    costBasis: number
    marketValue: number
    unrealizedReturnRate: number
    unrealizedProfitLoss: number
  }

  export interface PorfilioItem {
    symbol: string
    costBasis: number
    marketValue: number
    unrealizedReturnRate: number
    unrealizedProfitLoss: number
  }
  
  export interface Error {
    code: string
    description: string
  }