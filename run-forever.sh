#!/bin/bash

n=1

while true ; do
    if mkdir $n ; then
        cd $n
        ../run.sh
        cd ..
    fi

    n=$((n+1))
done
