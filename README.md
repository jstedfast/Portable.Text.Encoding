Portable.Text.Encoding
======================

A Portable Implementation of System.Text.Encoding.

## Goals

The main goal of this project is to supply a portable alternative to System.Text.Encoding that can be used
from other PCL libraries.

Platforms such as Silverlight and Windows Phone currently do not provide support for text encodings other
than a limited subset of the Unicode encodings. This can be a real show-stopper when you need to work with
legacy text encodings.

For example, while trying to make a PCL version of [MimeKit](https://github.com/jstedfast/MimeKit) available
for developers targetting Windows Phone, the biggest road block that I ran into was a lack of support for
charset conversion. While more and more mail software is moving toward using UTF-8, it's still common for
users to receive mail in other encodings. As you might imagine, a mail client that only supported receiving
mail that was encoded in UTF-8 would have very limited value to most users.

## Supported Text Encodings

So far, only ASCII, Latin1 (aka ISO-8859-1) and the Unicode (including UTF-8 and UTF-7) encodings are supported.

## TODO

Add a few more optionally-included assemblies for other Western encodings, CJK, Middle Eastern, and whatever
other encodings that may be desired.

## License Information

Portable.Text.Encoding is Copyright (C) 2014 Xamarin Inc. and is licensed under the MIT license:

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

## Installing via NuGet

The easiest way to install Portable.Text.Encoding is via 
[NuGet](https://www.nuget.org/packages/Portable.Text.Encoding/).

In Visual Studio's [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console),
simply enter the following command:

    Install-Package Portable.Text.Encoding

## Building

Just open up Portable.Text.Encoding.sln in your favorite IDE (Visual Studio, Xamarin Studio, SharpDevelop, etc) and hit "Build", it's that easy!

## Contributing

The first thing you'll need to do is fork Portable.Text.Encoding to your own GitHub repository. Once you do that,

    git clone git@github.com/<your-account>/Portable.Text.Encoding.git

Now you are ready to start hacking away on the code. When you're satisfied with your set of patches, commit
them to your GitHub fork and then send me a Pull Request and I'll review and merge your changes into the
official repo.

### Adding Support for Other Text Encodings

So far, all of the code has been taken directly from [Mono](https://github.com/mono/mono) and it should be fairly
straight-forward to "port" the [I18N](https://github.com/mono/mono/tree/master/mcs/class/I18N) assemblies over to
Portable.Text.Encoding.

I think the best coarse of action is to follow the same overall design of the I18N assemblies - in other words: 
create a new PCL project/assembly for each "region" (West, CJK, MidEast, Rare, Other). Once you've added all the
sources (and tables for those that have them), changed the namespace from `System.Text` to `Portable.Text`, and
set the PCL Profile to Profile136 (.NET 4.0, Silverlight 5, Windows Phone 8, Windows Store), just try building.
If there aren't any errors, you're done! If there are any compilation errors, here is the most common issue I've
run into so far and how to solve it:

##### Error: Missing compiler required member 'System.Runtime.CompilerServices.RuntimeHelpers.get_OffsetToStringData'

This error occurs when the compiler encounters code like this (where 's' is a string):

```csharp
fixed (char* charPtr = s) {
```

The way I've been solving this is to modify the code to be more like:

```csharp
var chars = s.ToCharArray ();

fixed (char* charPtr = chars) {
```

Sometimes, you'll find this pattern where only a subset of the string will actually be used (i.e. you'll have a `charIndex` and `charCount` available). When you find this pattern, you can instead do this:

```csharp
var chars = s.Substring (charIndex, charCount).ToCharArray ();

fixed (char* charPtr = chars) {
```

*WARNING:* You'll also need to fix up code within that `fixed` statement to use `0` instead of `charIndex`.

Unfortunately, this is less than ideal because what we're doing is duplicating the string in memory. Some profiles,
such as some of the .NET 4.5 profiles like Profile78, *do* support aliasing a string using a char pointer, so at
some point, it may be worth reconsidering the PCL Profile that Portable.Text.Encoding uses.

## Reporting Bugs

Have a bug or a feature request? [Please open a new issue](https://github.com/jstedfast/Portable.Text.Encoding/issues).

Before opening a new issue, please search for existing issues to avoid submitting duplicates.

## Documentation

There realistically doesn't need to be any real API documentation as the API is exactly the same as
System.Text.Encoding API, but I'm open to contributions in this area.
