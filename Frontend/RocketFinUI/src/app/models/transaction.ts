export interface Transaction {
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
    transactionId: string
    symbol: string
    shortName: string
    longName: string
    bid: number
    ask: number
    regularMarketPrice: number
    regularMarketDayHigh: number
    regularMarketDayLow: number
    regularMarketChange: number
    regularMarketChangePercent: number
    regularMarketOpen: number
    quantity: number
    pricePerShare: number
    purchaseDateAtUtcNow: string
  }

  export interface TransactionItem {
    transactionId: string
    symbol: string
    shortName: string
    longName: string
    bid: number
    ask: number
    regularMarketPrice: number
    regularMarketDayHigh: number
    regularMarketDayLow: number
    regularMarketChange: number
    regularMarketChangePercent: number
    regularMarketOpen: number
    quantity: number
    pricePerShare: number
    purchaseDateAtUtcNow: string
  }
  
  export interface Error {
    code: string
    description: string
  }