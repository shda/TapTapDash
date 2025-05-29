<?xml version="1.0" encoding="UTF-8"?>
<tileset version="1.10" tiledversion="1.11.2" name="map" tilewidth="128" tileheight="128" tilecount="64" columns="8">
 <image source="Map/atlas/map.png" width="1024" height="1024"/>
 <tile id="0">
  <properties>
   <property name="name" value="finish"/>
  </properties>
 </tile>
 <tile id="1">
  <properties>
   <property name="name" value="start"/>
  </properties>
 </tile>
 <tile id="2">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="3">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="4">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="5">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="6">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="7">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="8">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="9">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="10">
  <objectgroup draworder="index" id="2">
   <object id="2" x="0" y="0" width="61" height="58"/>
  </objectgroup>
 </tile>
 <tile id="12">
  <objectgroup draworder="index" id="2">
   <object id="2" x="67" y="70" width="61" height="58"/>
  </objectgroup>
 </tile>
 <tile id="13">
  <objectgroup draworder="index" id="2">
   <object id="2" x="0" y="67" width="58" height="61"/>
  </objectgroup>
 </tile>
 <tile id="14">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="15">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="16">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="17">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="18">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="19">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="20">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="21">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="22">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="23">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="24">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="25">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="26">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="27">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="28">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="29">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="30">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="31">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="32">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="33">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="34">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="35">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="1" y="0" width="127" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="36">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="37">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="38">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="39">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="83" height="90"/>
   <object id="2" x="2" y="0" width="126" height="128"/>
  </objectgroup>
 </tile>
 <tile id="40">
  <objectgroup draworder="index" id="2">
   <object id="1" x="1" y="0" width="127" height="128"/>
   <object id="2" x="0" y="0" width="126" height="128"/>
  </objectgroup>
 </tile>
 <tile id="41">
  <objectgroup draworder="index" id="2">
   <object id="1" x="15" y="0" width="113" height="128"/>
  </objectgroup>
 </tile>
 <tile id="42">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="113" height="128"/>
  </objectgroup>
 </tile>
 <tile id="43">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="113" height="128"/>
  </objectgroup>
 </tile>
 <tile id="44">
  <objectgroup draworder="index" id="2">
   <object id="1" x="15" y="0" width="113" height="128"/>
  </objectgroup>
 </tile>
 <tile id="45">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="2" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="46">
  <objectgroup draworder="index" id="2">
   <object id="2" x="40" y="0" width="47" height="128"/>
  </objectgroup>
 </tile>
 <tile id="47">
  <objectgroup draworder="index" id="2">
   <object id="4" x="0" y="0">
    <polygon points="0,0 128,0 126.653,19.4021 90.2737,25.0611 88.3874,127.461 39.8821,127.192 39.8821,23.9832 4.31158,24.2526"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="48">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="3" x="1.07789" y="40.96">
    <polygon points="0,0 102.669,-0.808421 104.017,-36.9179 123.958,-39.3432 125.844,85.4232 105.903,85.6926 101.861,48.2358 -0.269474,46.8884"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="49">
  <objectgroup draworder="index" id="2">
   <object id="3" x="2.96421" y="127.192">
    <polygon points="0,0 -1.34737,-22.3663 36.9179,-23.4442 37.7263,-126.922 84.8842,-126.653 84.8842,-28.5642 118.299,-23.4442 122.88,0.269474"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="50">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
   <object id="3" x="25.3305" y="3.23368">
    <polygon points="0,0 -0.808421,35.84 101.322,37.1874 101.592,85.1537 -2.96421,85.1537 -1.34737,123.149 -23.1747,123.419 -24.2526,-3.50316"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="51">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="52">
  <objectgroup draworder="index" id="2">
   <object id="2" x="2.69474" y="1.07789">
    <polygon points="0,0 124.227,1.34737 122.072,25.3305 85.1537,25.0611 85.6926,102.4 122.611,103.747 123.149,126.653 -1.07789,126.383 -0.808421,104.286 38.8042,102.669 37.9958,23.9832 -2.15579,21.8274"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="53">
  <objectgroup draworder="index" id="2">
   <object id="2" x="0.538947" y="2.96421">
    <polygon points="0,0 26.4084,-0.269474 26.4084,37.4568 102.4,37.1874 105.903,-2.69474 127.192,-1.34737 125.844,124.497 102.939,124.497 102.131,85.1537 25.8695,85.1537 24.2526,125.036 0.269474,124.497"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="54">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="55">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="56">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="57">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="58">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
 <tile id="59">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="128" height="128"/>
  </objectgroup>
 </tile>
</tileset>
