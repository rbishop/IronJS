// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
* @name: S15.5.4.15_A1_T1;
* @section: 15.5.4.15;
* @assertion: String.prototype.substring (start, end);
* @description: Arguments are false and true, and instance is object;
*/


// Converted for Test262 from original Sputnik source

ES5Harness.registerTest( {
id: "S15.5.4.15_A1_T1",

path: "TestCases/15_Native/15.5_String_Objects/15.5.4_Properties_of_the_String_Prototype_Object/15.5.4.15_String.prototype.substring/S15.5.4.15_A1_T1.js",

assertion: "String.prototype.substring (start, end)",

description: "Arguments are false and true, and instance is object",

test: function testcase() {
   var __instance = new Object(true);

__instance.substring = String.prototype.substring;

//////////////////////////////////////////////////////////////////////////////
//CHECK#1
if (__instance.substring(false, true) !== "t") {
  $ERROR('#1: __instance = new Object(true); __instance.substring = String.prototype.substring;  __instance.substring(false, true) === "t". Actual: '+__instance.substring(false, true) );
}
//
//////////////////////////////////////////////////////////////////////////////

 }
});
