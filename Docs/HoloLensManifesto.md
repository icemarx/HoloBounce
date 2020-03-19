# HoloLens Manifesto

Manifesto opisuje nekaj konvecij, ki naj bi se jih držali da ostane koda berljvia in lepa.

## Koda
- Uporabljaj documentation comments
- Variable and method names		
- Spremenljivke naj bodo descriptive
    - RigidBody = rb
    - Transform = tr
    - User Interface = UI
- Uporablja se camelCase
    - razen v primeru znanih kratic (npr. User Interface = UI, Heads Up Display = HUD, …)

## Editor
Object -> make prefab <br>
skripta: ObjectController

## Commits
The commits shuold be descriptive. If the commit does not fit in one line ( < 60 chars), make a title and then write the commit below in detail. Add one empty line between title and description.
<br>

## Footnotes:

- Rigidbody item_rb; 	// item rigidbody; item == object that was picked up 
- trgbd = t.GetComponent<Rigidbody>();

GameManager: 
  1. referenca na playerja
  2. referenca na žoge
  3. playerju, žogam in UI referenca na gamemanager
  4. zamenjat vse public variables ki se sklicujejo na stalne objekte (player, ball), s klici v gamemanager (get, set metode)
