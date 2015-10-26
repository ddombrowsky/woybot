#!/bin/bash

n=1

while true ; do
    d=`printf nh%04d $n`
    if mkdir $d ; then
        cd $d
        ../run.sh
        cd ..
    fi

    n=$((n+1))
done
