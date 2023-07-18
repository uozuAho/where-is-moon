# Where is the Moon?

Realistically simulate the Moon's position relative to Earth, so that you can
tell where the moon is now, and where it's going to be in the future.

# todo
- orbit earth around sun
- tilt moon, incline orbit
- add time controls
    - speed, pause
- rotate moon

# later/maybe
- move player
- restrict up/down look to 90 degrees
- ui: show where player is on 2d earth map
- ui: add compass
- ui: show current lat long
- ui: show the current time
- ui: user can set date and time
- the moon's not currently to scale. Why does it look so small from Earth?
    - camera FOV? zooming in makes everything else look huge
- how to credit asset creators?
    - https://assetstore.unity.com/packages/3d/environments/planets-of-the-solar-system-3d-90219
- start from space
    - position camera on Earth surface & look up, eg. double click on a city,
      camera goes there and looks up

# stuff learned to make this work
- [ecliptic](https://en.wikipedia.org/wiki/Ecliptic)
    - the plane formed by Earth's orbit around the sun
    - Earth's rotational axis is about 23.4 degrees off the ecliptic
- the Moon orbits the Earth about once every 27.32 days, relative to the stars (
  or the Unity editor)
    - it orbits in a prograde direction - the same direction as the rotation of
      the Earth
    - https://en.wikipedia.org/wiki/Orbit_of_the_Moon
    - https://en.wikipedia.org/wiki/Retrograde_and_prograde_motion
