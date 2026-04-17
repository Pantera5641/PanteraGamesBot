mkdir -p AppDir/usr/bin
cp LyriumAPM AppDir/usr/bin/

mkdir -p AppDir/usr/share/applications
nano AppDir/usr/share/applications/lyrium.desktop

linuxdeployqt AppDir/usr/bin/LyriumAPM -appimage
