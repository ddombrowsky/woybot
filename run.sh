#!/bin/bash

n=0
d=`dirname $0`

while true ; do 
    fn=`printf nh%04d $n`
    ttyrec -e "/bin/sh -c '$d/woybot-core.expect  -- -l 2> ${fn}.expect.log'" ${fn}.ttyrec
    mv death.log ${fn}.death.log || exit
    n=$((n+1))
done
