import { Button } from "@/components/ui/button"
import { Input } from '@/components/ui/input'

export default function Login() {
  return (
    <section className='w-[25rem] mt-[25%] m-auto'>
      <Input className='mb-4' type="email" placeholder="Email" />
      <Input className='mb-4' type="password" placeholder="Password" />
      <Button className='mx-auto'>
        Login
      </Button>
    </section>

  )
}
