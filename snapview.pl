#!/usr/bin/perl -n
#

BEGIN {
    $lnum = 0;
    $frame = 0;
    sub clear() {
        print(chr(0x1b)."[H".chr(0x1b)."[K".chr(0x1b)."[H".chr(0x1b)."[J");
        print($frame."\n");
        $frame++;
    }
    clear();
}

if (/^scr/) {
    print $_;
    $lnum++;
    if ($lnum == 30) {
        sleep 1;
        $lnum = 0;
        clear();
    }
}
