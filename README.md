# PutridParrot.Utilities

Utility and/or common classes ported from some of my very old source libraries

## Range

Ranges takes an lower and upper value of a type which implements IComparable<T>. The values
can be passed in any order (i.e. lowest first or lowest last) and the values are seen as
inclusive.

Standard functionality exists to get the min or max of the range, to check if a range contains
a given value or Range as well as an intersection method which returns a new Range.

## Serialization

Includes generalised serialization functionality

## EnumDescriptor

Allows the use of Description attributes along with enumeration values and functionality
for getting and parsing the enumeration via these descriptions - useful in situations such
as UI displaying enumerated values but want to display something more readable.

## Disposables

Acts as a collection of IDisposable objects allows all to be called when the Disposables object
is disposed of.

## Condition

Includes a bunch of functions, similar to Asserts on unit test etc. which can be used to simplify
preconditions or general code tests.