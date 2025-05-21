<?xml version="1.0" encoding="UTF-8"?>
<tileset version="1.10" tiledversion="1.11.2" name="atlas" tilewidth="64" tileheight="64" tilecount="9" columns="3">
 <image source="Images/Atlas/atlas.png" width="192" height="192"/>
 <tile id="0">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0" width="64" height="64"/>
  </objectgroup>
 </tile>
 <tile id="1">
  <properties>
   <property name="direction" value="down"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
 </tile>
 <tile id="2">
  <properties>
   <property name="direction" value="up"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
 </tile>
 <tile id="3">
  <properties>
   <property name="direction" value="left"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
 </tile>
 <tile id="4">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="false"/>
  </properties>
 </tile>
 <tile id="5">
  <properties>
   <property name="direction" value="right"/>
   <property name="isJump" type="bool" value="true"/>
  </properties>
 </tile>
 <tile id="6">
  <properties>
   <property name="name" value="start"/>
  </properties>
 </tile>
 <tile id="7">
  <properties>
   <property name="name" value="finish"/>
  </properties>
 </tile>
</tileset>
