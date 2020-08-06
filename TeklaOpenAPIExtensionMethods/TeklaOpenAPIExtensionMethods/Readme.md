From version 2.2.0 I've added added preprocessor directive "NOT_TSD" to files which include drawing API. 
I noticed that i dont need drawing api when i develop model plugin so from now this codes are optional.

If you dont want to have codes which need reference to the Tekla.Structures.Drawing.dll then
open properties of your project, goto "Build" > "Conditional compilation symbols" and add symbol "NOT_TSD"

Official github repository:

https://github.com/dawiddyrcz/Tekla-Open-Api-Extension-Methods

You can contribute your own methods.
