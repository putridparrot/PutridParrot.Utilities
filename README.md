# PutridParrot.Utilities

[![Build PutridParrot.Utilities](https://github.com/putridparrot/PutridParrot.Utilities/actions/workflows/build.yml/badge.svg)](https://github.com/putridparrot/PutridParrot.Utilities/actions/workflows/dotnet-core.yml)
[![NuGet version (PutridParrot.Utilities)](https://img.shields.io/nuget/v/PutridParrot.Utilities.svg?style=flat-square)](https://www.nuget.org/packages/PutridParrot.Utilities/)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/putridparrot/PutridParrot.Utilities/blob/master/LICENSE.md)
[![GitHub Releases](https://img.shields.io/github/release/putridparrot/PutridParrot.Utilities.svg)](https://github.com/putridparrot/PutridParrot.Utilities/releases)
[![GitHub Issues](https://img.shields.io/github/issues/putridparrot/PutridParrot.Utilities.svg)](https://github.com/putridparrot/PutridParrot.Utilities/issues)

Utility and/or common classes ported from some of my very old source libraries

## Range

Ranges takes an lower and upper value of a type which implements IComparable<T>. The values
can be passed in any order (i.e. lowest first or lowest last) and the values are seen as
inclusive.

Standard functionality exists to get the min or max of the range, to check if a range contains
a given value or Range as well as an intersection method which returns a new Range.

## EnumDescriptor

Allows the use of Description attributes along with enumeration values and functionality
for getting and parsing the enumeration via these descriptions - useful in situations such
as UI displaying enumerated values but want to display something more readable.

## Disposables

Acts as a collection of IDisposable objects allows all to be called when the Disposables object
is disposed of.

## ActionDisposable

Useful in situations where you want some methods/functions called when something is disposed of, for example if aggregating IDisposables into a single IDisposable then you can add method/function calls to the CompositeDisposable (or similar).
