# Where is the Moon?

Realistically simulate the Moon's position relative to Earth, so that you can
tell where the moon is now, and where it's going to be in the future.

# todo
- fix earth rotation so time is correct
- move time offset calcs to time controller? add time since dec solstice?
- ui: time forward/back slider
- fix moon orbit position so that it's correct relative to real time
- tilt moon, incline orbit
- rotate moon

# later/maybe
- ui: add compass
- move player
- restrict up/down look to 90 degrees
- ui: show where player is on 2d earth map
- ui: show current lat long
- ui: user can set date and time
- simulate libration: https://en.wikipedia.org/wiki/Libration
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
- there are 366 days in a [sidereal year](https://en.wikipedia.org/wiki/Sidereal_time)
- the December solstice isn't always on the 21st December: https://en.wikipedia.org/wiki/Summer_solstice
