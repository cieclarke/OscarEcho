# Vending Machine Kata

>```git clone git@github.com:cieclarke/OscarEcho.git myfolder```

>```cd myfolder```

>```dotnet build```

>```dotnet test -t```

>```dotnet test```

>```dotnet run```


## Notes

The system uses a payment token convertor based on dimensions. This abstraction is becasue the vending machine does not know about coins as such but only dimensions of what is being used to pay.

The `Slot` object is analogues to the spiral in a vending machine. `Snacks` are placed in the spiral where the purchaser selects the item in that queue of snacks. So the `Slot` holds the price not the `Snack`.

Payments are using GBP.

## Development notes

Code is in the folder `OscarEcho/VMK`

Breaking down the functionaltiy of the vending machine could be done by component. Refactor the VendingMachine class to objects like `ChangeBox`, `CoinSlotAnalyser`, `Stock` etc. It would make the testing less functional and break it more into units.
