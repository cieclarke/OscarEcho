﻿#Vending Machine Kata

`git clone git@github.com:cieclarke/OscarEcho.git myfolder`
`cd myfolder`
`dotnet build`
`dotnet test -t`
`dotnet test`
`dotnet run`

## Notes

The system uses a payment token convertor based on dimensions. This abstraction is becaasue the vending machine does not know about coins as such but only diensions of what is being used to pay.

The `Slot` object is analogues to the spiral in a vending machine. `Snacks` are placed in the spiral where the purchaser selects the item in that queue of snacks. So the `Slot` holds the price not the `Snack`.

Payments are using GBP.

## Development notes

Breaking down the functionaltiy of the vending machine can be done by component. REfactor the VendingMachine class to objects like `ChangeBox`, `Stock` etc. It would make the testing less functional and break it into units more.

