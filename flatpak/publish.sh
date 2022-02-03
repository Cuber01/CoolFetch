mv Moofetch moofetch
flatpak-builder build-dir org.flatpak.Moofetch.json --force-clean
flatpak build-export ./repo/ ./build-dir/
flatpak build-bundle ~/RiderProjects/Moofetch/flatpak/repo moofetch.flatpak org.flatpak.Moofetch
echo "Done"
