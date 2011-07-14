// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
* @name: S15.11.3.1_A4_T1;
* @section: 15.11.3.1, 16;
* @assertion: The Error has property prototype;
* @description: Checking Error.hasOwnProperty('prototype');
*/


// Converted for Test262 from original Sputnik source

ES5Harness.registerTest( {
id: "S15.11.3.1_A4_T1",

path: "TestCases/15_Native/15.11_Error_Objects/15.11.3_Properties_of_the_Error_Constructor/S15.11.3.1_A4_T1.js",

assertion: "The Error has property prototype",

description: "Checking Error.hasOwnProperty(\'prototype\')",

test: function testcase() {
   //////////////////////////////////////////////////////////////////////////////
//CHECK#1
if (!(Error.hasOwnProperty('prototype'))) {
  $ERROR('#1: Error.hasOwnProperty(\'prototype\') return true. Actual: '+Error.hasOwnProperty('prototype'));
}
//
//////////////////////////////////////////////////////////////////////////////

 }
});
