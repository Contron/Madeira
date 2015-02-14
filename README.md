# Madeira

A C# library with the barebone necessities in order to kickstart a 2D or 3D game, giving you full control of how it's rendered.

## Philosophy

I created this library out of frustration with the existing solutions for OpenTK. SFML.NET - while being very good - forces you to strictly abide by the SFML way of doing things.

For instance in SFML, to get a rectangle to draw on the screen you need to create a `Rectangle` class, and then explicitly call its `Draw` method. While this is all perfect for simple graphics, it gets quite cumbersome if you have your own `Vector` classes, or if you want to change its size, as you need to call its setter methods each time you do.

Madeira on the other hand simply provides you with convenience methods to aid in drawing - while giving you full control of how it works. For instance, to draw a rectangle is just one method call - you provide a `Point` for its position, and a `Point` for its size. If you don't want to use the standard classes, Madeira also lets you use simple X and Y values if you're rolling something your own.

It also comes with a few more miscellaneous boilerplate features, including loading textures, loading and playing sounds, and simple font rendering.